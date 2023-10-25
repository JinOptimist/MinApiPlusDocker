cd CoolRpg

docker build . --rm -t rpg/server:latest

docker run -e ASPNETCORE_URLS=http://+:80 -p 8082:80 --name rpg rpg/server