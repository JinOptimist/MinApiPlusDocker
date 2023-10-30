docker network create rpg-network


start cmd /c rise-rabbitmq.bat
REM 'may be we should wait untill rabbit is go up before run next containers'
start cmd /c rise-dockers-npc.bat
start cmd /c rise-dockers-rpg.bat
