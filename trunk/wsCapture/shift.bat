:loop
@echo off&echo\
set num=
set num=%num%
echo û��λ�Ĳ���Ϊ : 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20
echo\&echo ���� 1234 ʼ��û�б仯���������ȴ����λ�仯��ǰ�ơ�
echo\
:: ���ߣ����   @bbs.bathome.cn   2007-11-10
::
call :lis 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20
color 0b
echo\&echo �������,��������˳� ����
echo\&pause>nul&exit
:lis
set /p=%num%<nul
if "%5"=="" goto :eof
shift /5
set /p=��λ��Ĳ���Ϊ : %1 %2 %3 %4 %5 %6 %7 %8 %9<nul
set /p=     �����������......<nul
pause>nul
goto lis

