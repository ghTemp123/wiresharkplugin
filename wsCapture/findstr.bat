@echo off
:begin
cls
set input=
set /p input=  ������һ���ַ�����
if "%input%"=="" goto begin
echo.
echo %input%|findstr "^[0-9]*$">nul && echo   ��������ַ����Ǵ�����||(
    echo %input%|findstr "^[a-zA-Z]*$">nul && echo   ��������ַ����Ǵ���ĸ||echo   ��������ַ����Ȳ��Ǵ�����Ҳ���Ǵ���ĸ
)
echo.
pause
goto begin


