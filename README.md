# ExampleXMLInterface
이 프로젝트는 Lumosity XML protocol 을 보다 쉽고 직관적으로 사용할 수 있도록 설계된 .NET Framework 기반의 오픈 소스 클래스 라이브러리입니다. 이 라이브러리는 Sample 코드와 함께 제공되며, XML 인터페이스를 소켓 (Socket) 에 연결해 데이터 송수신 기능을 구현하는 데 필요한 시간을 단축하기 위해 제작되었습니다.

## Lumosity Software Interface Sample
![Lumosity Software Interface](https://github.com/Shinhotek/LumositySWInterface/assets/157770885/de59d64f-7c72-4cbc-93bd-d83dc79e0fc2)

### Lumosity Software 인터페이스 설명서 :
[Lumosity Software Interface Manual (PDF)](https://github.com/Shinhotek/LumositySWInterface/files/14274322/Lumosity.software.based.on.netFramework.Interface.Manual.pdf)

### Lumosity Software 다운로드 링크 :
- **x64 (64-bit) Setup (.msi)** : [다운로드 링크](http://gofile.me/6HWVE/RUD2fLnOa)
- **x86 (32-bit) Setup (.msi)** : [다운로드 링크](http://gofile.me/6HWVE/A3whil6Xx)

## 개요
**ExampleXMLInterface** 는 Lumosity XML 인터페이스를 활용하여 다양한 데이터 처리 및 장치 제어 기능을 제공하는 Windows Forms 애플리케이션입니다. 이 프로젝트는 카메라 설정, 데이터 평가, 이미지 처리 및 기타 관련 작업을 수행할 수 있는 기능을 포함합니다.

## 주요 특징
- **사용 및 수정 가능** : 제공된 코드는 자유롭게 사용 및 수정할 수 있습니다.
- **효율성 향상** : 기존 XML 인터페이스를 소켓과 연결해 효율적으로 데이터 통신을 처리합니다.
- **Sample Code 제공** : 구현을 돕는 예제 코드를 포함하고 있습니다.

## 주요 기능
- **Lumosity XML 인터페이스 통합** : XML 기반 통신을 통해 데이터 평가 및 장치 제어.
- **카메라 제어** :
  - 해상도, ROI (Region of Interest), 노출 시간, 밝기 설정 등 다양한 카메라 설정 지원.
  - 자동 및 수동 제어 모드 제공.
- **이미지 처리** :
  - 블러 (Blur) 처리, 배경 제거, 섹션 분석 등 다양한 이미지 처리 기능.
- **데이터 평가** :
  - 실시간 데이터 평가 및 결과 표시.
  - 평가 항목 추가 / 제거 및 결과 데이터 시각화.
- **파일 입출력** :
  - TIFF 이미지 파일 로드 및 저장.
  - 설정 파일 (INI) 저장 및 불러오기.

## 설치 및 실행
1. **필수 요구사항** :
   - .NET Framework 4.8 이상
   - Visual Studio 2022
2. **빌드 및 실행** :
   - Visual Studio에서 솔루션 파일을 엽니다.
   - `ExampleXMLInterface` 프로젝트를 빌드합니다.
   - 빌드가 완료되면 애플리케이션을 실행합니다.

## 사용법
1. **연결 설정 :**
   - Connect 버튼 Click -> Lumosity 와 연결
   - IP 주소와 포트를 입력한 후 "Connect" 버튼을 클릭하여 장치에 연결합니다.</br></br>
     ![image](https://github.com/user-attachments/assets/e0135510-e1dc-4ccb-aa95-58bd57a05bd2)
2. **카메라 설정 :**
   - Get info (Refresh) Click -> 현재 정보에 대한 업데이트
   - 카메라 해상도, ROI, 노출 시간 등을 설정합니다.</br></br>
     ![image](https://github.com/user-attachments/assets/dfd8c0e4-4765-47d5-8058-6b96b36b2a28)
4. **데이터 평가 :**
   - Evaluation Avalilable items 에서 평가 결과를 확인할 항목 Check
   - 평가 항목을 선택하고 데이터를 실시간으로 확인합니다.</br></br>
     ![image](https://github.com/user-attachments/assets/a9ab48fa-ff6c-4f34-87de-55ac47a3485f)
5. **이미지 처리 :**
   - Evaluation Option 의 Continuous Check -> Frame 마다 업데이트
   - 블러 모드, 배경 제거 등을 설정하여 이미지를 처리합니다.</br></br>
     ![image](https://github.com/user-attachments/assets/4ad920d1-74fc-480f-ad3c-b6002b68ba3f)
6. **파일 관리 :**
   - TIFF 이미지를 로드하거나 저장합니다.
   - 설정 파일을 저장하거나 불러옵니다.
7. **카메라 제어 :**:
   - Start / Stop 으로 카메라 구동하여 측정 시작 / 정지</br></br>
     ![image](https://github.com/user-attachments/assets/37756c9a-08be-472e-82b6-5827e70a3a72)

## 주요 클래스 및 구조
- **XMLInterface** :
  - Lumosity XML 통신을 처리하는 주요 클래스.
  - 데이터 평가, 카메라 제어, 이미지 처리 기능 포함.
- **Form1** :
  - 사용자 인터페이스 (UI) 를 관리하는 메인 폼.
  - 버튼, 텍스트 박스, 체크박스 등을 통해 사용자 입력 처리.
- **FramePreview** :
  - 실시간 프레임 미리보기 및 이미지 시각화.

## 기여
이 프로젝트에 기여하시기를 희망하시는 경우, Pull Request 를 제출하시거나 Issue 를 생성해 주세요.

## 라이선스
이 프로젝트는 [MIT 라이선스](LICENSE) 를 따릅니다.
