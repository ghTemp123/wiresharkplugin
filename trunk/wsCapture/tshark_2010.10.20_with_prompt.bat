@echo off
echo *******************************************************************************
@echo 2010.10.20 ���ݰ�Gi�ɼ�
echo *******************************************************************************
if exist e:\Progra~1\Wireshark\tshark.exe goto e
if exist f:\Progra~1\Wireshark\tshark.exe goto f
if exist c:\Progra~1\Wireshark\tshark.exe goto c
if exist d:\Progra~1\Wireshark\tshark.exe goto d
:c
c:
cd c:\Program Files\Wireshark 
goto tshark
:d
d:
cd d:\Program Files\Wireshark 
goto tshark
:e
e:
cd e:\Program Files\Wireshark 
goto tshark
:f
f:
cd f:\Program Files\Wireshark 
goto tshark
:tshark
tshark -D
echo ******************************************************************************* 
@echo ָ���ɼ��˿�,���߶˿������ֱ�ʾ�����߶˿������� -p��ʾ
@echo ���磺3��2 -p
set/p port=
echo *******************************************************************************
echo ָ���˲ɼ��˿�*** %port% ***
echo ָ��ÿ���ļ���С1.024G
echo �ɼ��ļ�Ŀ¼f��
echo Ctrl+Cֹͣ
echo *******************************************************************************
tshark -i %port% -w f:\t.pcap -b filesize:1024000 
pause




����