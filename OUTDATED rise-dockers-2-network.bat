# docker network create --driver nat rpg-network
docker network create rpg-network
docker network connect rpg-network rpg
docker network connect rpg-network npc
docker network connect rpg-network rabbitmq