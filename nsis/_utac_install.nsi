;--------------------------------

;--------------------------------
;Include Modern UI

  !include "MUI.nsh"

;--------------------------------


; The name of the installer
Name "USB TEMPer Advanced Control"

XPStyle on

; The file to write
OutFile "utac_installer.exe"

; The default installation directory
InstallDir $PROGRAMFILES\UTAC

!define MUI_FINISHPAGE_LINK "visit www.n4rf.net for more information and updates"
!define MUI_FINISHPAGE_LINK_LOCATION "http://www.n4rf.net"

!define MUI_FINISHPAGE_RUN "$INSTDIR\UTAC.exe"
!define MUI_FINISHPAGE_NOREBOOTSUPPORT

  !define MUI_LANGDLL_REGISTRY_ROOT "HKCU" 
  !define MUI_LANGDLL_REGISTRY_KEY "Software\Modern UI Test" 
  !define MUI_LANGDLL_REGISTRY_VALUENAME "Installer Language"

;--------------------------------

;Pages
  
  !insertmacro MUI_PAGE_WELCOME
  ;!insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "German"
  !insertmacro MUI_LANGUAGE "English"
  !insertmacro MUI_LANGUAGE "Spanish"
  !insertmacro MUI_LANGUAGE "Italian"
  !insertmacro MUI_LANGUAGE "French"
  !insertmacro MUI_LANGUAGE "Dutch"
;--------------------------------

;--------------------------------

;--------------------------------
;Installer Functions

Function .onInit

  !insertmacro MUI_LANGDLL_DISPLAY

FunctionEnd

;--------------------------------

; The stuff to install
Section "UTAC Programm (required)"

  SectionIn RO
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File UTAC.exe
  File ZedGraph.dll

  SetOutPath $INSTDIR\WebServer
  File WebServer\webserver.tpl

  SetOutPath $INSTDIR\Lang
  File lang\es.xml
  File lang\de.xml
  File lang\en.xml
  File lang\it.xml
  File lang\fr.xml
  File lang\nl.xml

  SetOutPath $INSTDIR

  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\UTAC "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\UTAC" "DisplayName" "UTAC"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\UTAC" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\UTAC" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\UTAC" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
SectionEnd ; end the section


; Optional section (can be disabled by the user)
Section "Start Menu"

  CreateDirectory "$SMPROGRAMS\UTAC"
  CreateShortCut "$SMPROGRAMS\UTAC\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\UTAC\USB TEMPer Advanced Control.lnk" "$INSTDIR\UTAC.exe" "" "$INSTDIR\UTAC.exe" 0
  
SectionEnd



; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\UTAC"
  DeleteRegKey HKLM SOFTWARE\UTAC

  ; Remove files and uninstaller
  Delete $INSTDIR\UTAC.exe
  Delete $INSTDIR\utacsettings.xml
  Delete $INSTDIR\uninstall.exe
  
  Delete $INSTDIR\WebServer\webserver.tpl
  
  Delete $INSTDIR\Lang\de.xml
  Delete $INSTDIR\Lang\es.xml
  Delete $INSTDIR\Lang\en.xml
  Delete $INSTDIR\Lang\it.xml
  Delete $INSTDIR\Lang\fr.xml
  Delete $INSTDIR\Lang\nl.xml
  
  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\UTAC\*.*"

  ; Remove directories used
  RMDir "$SMPROGRAMS\UTAC"
  RMDir "$INSTDIR"

SectionEnd
