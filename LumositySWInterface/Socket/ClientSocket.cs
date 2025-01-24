using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common.Sock
{
    internal class ClientSocket
    {
        internal class StateObject
        {
            // Client  socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 52428800;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }

        public enum ClientStatus { None, Connecting, Conected, }

        Socket _client = null;

        string _strDnsname = "127.0.0.1";
        int _nPort = 5555;
        BackgroundWorker _bgwConnecting = new BackgroundWorker();
        bool _bIsConnected = false;
        int _nConnectTimeout = 7000;
        ClientStatus _enStatus = ClientStatus.None;        

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        public delegate void DataReceiveHandler(Socket handler, string data);
        public delegate void DisconnectedHandler(Socket handler);

        public event DataReceiveHandler dataReceiveEvent;
        public event DisconnectedHandler disconnectedEvent;

        // The response from the remote device.  
        private static String response = String.Empty;

        string _strParseContentStart = "";
        string _strParseContentEnd = "<EOF>";

        string _strEncoding = "EUC-KR";


        public string ParseContentStart
        {
            get { return _strParseContentStart; }
            set { _strParseContentStart = value; }
        }

        public string ParseContentEnd
        {
            get { return _strParseContentEnd; }
            set { _strParseContentEnd = value; }
        }

        public ClientStatus CommStatus
        {
            get { return _enStatus; }
        }

        public string EncodingType
        {
            get { return _strEncoding; }
            set { _strEncoding = value; }
        }


        public ClientSocket()
        {
            _bgwConnecting.WorkerSupportsCancellation = true;
            _bgwConnecting.DoWork += Connect;
        }

        public bool IsConnected
        {
            get 
            { 
                if (_client != null)
                {
                    return _client.Connected;
                }

                return false;
            }
        }

        public void StartConnect(string dnsname, int port, DataReceiveHandler func, int timeOut = 7000)
        {
            if (!_bgwConnecting.IsBusy)
            {
                dataReceiveEvent += func;
                _strDnsname = dnsname;
                _nPort = port;
                _nConnectTimeout = timeOut;
                _bgwConnecting.RunWorkerAsync();
            }
        }

        public void Disconnect()
        {
            connectDone.Set();
            _bgwConnecting.CancelAsync();
            if (_client != null)
            {
                if (_client.Connected)
                {
                    _client.Disconnect(false);
                }

                _client.Close();
                _client = null;
            }

            _enStatus = ClientStatus.None;
        }

        private void Connect(object sender, DoWorkEventArgs e)
        {
            connectDone.Reset();

            IPAddress ipAddress = IPAddress.Parse(_strDnsname);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, _nPort);

            // Create a TCP/IP socket.  
            _client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.  
            _client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), _client);
            _enStatus = ClientStatus.Connecting;
            _bIsConnected = connectDone.WaitOne(_nConnectTimeout);
            if (!_client.Connected)
            {
                if (dataReceiveEvent != null)
                {
                    dataReceiveEvent(_client, "Connected Failed");
                    //_client.Shutdown(SocketShutdown.Both);
                    _client.Close();
                    _bIsConnected = false;
                    _bgwConnecting.CancelAsync();
                }

                _enStatus = ClientStatus.None;
            }
            else
            {
                _enStatus = ClientStatus.Conected;
                Receive(_client);
            }

            connectDone.Reset();
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                if (client.Connected)
                {
                    // Complete the connection.  
                    client.EndConnect(ar);
                }
                


                //Console.WriteLine("Socket connected to {0}",
                //    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception E)
            {
                //LogFile.LogExceptionErr(E.ToString());
                Console.WriteLine(E.ToString());
            }
        }

        public void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            //byte[] byteData = Encoding.ASCII.GetBytes(data);
            byte[] byteData = Encoding.GetEncoding(_strEncoding).GetBytes(data);

            // Begin sending the data to the remote device.  
            _client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), _client);
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                if (client.Connected)
                {
                    // Begin receiving the data from the remote device.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }                
            }
            catch (Exception E)
            {
                //LogFile.LogExceptionErr(E.ToString());
                Console.WriteLine(E.ToString());
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                //Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception E)
            {
                //LogFile.LogExceptionErr(E.ToString());
                Console.WriteLine(E.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                if (client.Connected)
                {
                    // Read data from the remote device.  
                    int bytesRead = client.EndReceive(ar);

                    //Console.WriteLine("Received " + bytesRead + "Bytes from server");
                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.  
                        //state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                        state.sb.Append(Encoding.GetEncoding(_strEncoding).GetString(state.buffer, 0, bytesRead));

                        // Check for end-of-file tag. If it is not there, read   
                        // more data.  
                        content = state.sb.ToString();
                        int startIndex = content.IndexOf(_strParseContentStart);
                        int endIndex = content.IndexOf(_strParseContentEnd);
                        if (startIndex > -1 && endIndex != -1 && startIndex != endIndex)
                        {
                            receiveDone.Set();
                            if (dataReceiveEvent != null)
                            {
                                try
                                {
                                    string strXml = content.Substring(startIndex, endIndex - startIndex + _strParseContentEnd.Length);
                                    dataReceiveEvent(_client, strXml);
                                    state.sb.Clear();
                                }
                                catch (Exception E)
                                {
                                    //LogFile.LogExceptionErr(E.ToString());
                                    Console.WriteLine(E.ToString());
                                    //LogFile.LogExceptionErr("ClientSockt error data : " + content);
                                    state.sb.Clear();
                                }
                            }
                        }
                    }
                    else
                    {
                        //// All the data has arrived; put it in response.  
                        //if (state.sb.Length > 1)
                        //{
                        //    response = state.sb.ToString();
                        //}
                        //// Signal that all bytes have been received.  
                        //receiveDone.Set();

                        _client.Disconnect(false);
                        _client.Close();
                        disconnectedEvent(_client);
                    }

                    try
                    {
                        // Get the rest of the data.  
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                    catch (Exception)
                    {
                    }
                }                
            }
            catch (Exception E)
            {
                disconnectedEvent(_client);
                //LogFile.LogExceptionErr(E.ToString());
                Console.WriteLine(E.ToString());
            }
        }        
    }
}
