@echo off
@echo *******************************************************************************
@echo 2010.10.21 �ƶ�qq���ݰ�Gi�ɼ�
@echo *******************************************************************************
if exist c:\Progra~1\Wireshark\tshark.exe goto c
if exist d:\Progra~1\Wireshark\tshark.exe goto d
if exist e:\Progra~1\Wireshark\tshark.exe goto e
if exist f:\Progra~1\Wireshark\tshark.exe goto f
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

:loop

@echo *******************************************************************************
@echo ָ���ɼ��˿�
@echo ���߶˿������ֱ�ʾ�����磺3
@echo ���߶˿������� -p��ʾ�����磺2 -p
set port= 
set/p port=��ָ���ɼ��˿�:


@echo *******************************************************************************
@echo ָ���˲ɼ��˿�*** %port% ***
@echo ָ��ÿ���ļ���С1.024G,�ɼ��ļ�Ŀ¼f��
@echo ���ˣ�TCP�˿�14000��UDP�˿�8040
@echo ���ˣ�TM 8000��4000
@echo ���ˣ�oicqЭ����˷�����ʱ����ʹ��
@echo Ctrl+Cֹͣ
@echo *******************************************************************************
tshark -i %port%  -w f:\t.pcap -b filesize:1024000 -f "tcp port 14000 or udp port 8040 or udp port 8000 or udp port 4000" 

pause
goto loop




����