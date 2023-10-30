docker pull rabbitmq:3.10-management
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 --network rpg-network rabbitmq:3.10-management
