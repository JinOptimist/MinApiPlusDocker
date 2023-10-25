cd NpcApi

docker build . --rm -t npc_api/server:latest

docker run -e ASPNETCORE_URLS=http://+:80 -p 8081:80 --name npc npc_api/server
