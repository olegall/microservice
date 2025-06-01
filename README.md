https://habr.com/ru/articles/649363/

«апустить проекты ActivityLogger, ProductCatalog, ShoppingCart, WebUI

TODO
- добавить RabbitMQ
- добавить Docker

RabbitMQ
“естирование: 
1. запустить все приложени€, RabbitMQ: д. всЄ работать, логи
2. остановить RabbitMQ
3. никакие действи€ по кнопкам интерфейса не работают
4. включить RabbitMQ. выполн€етс€ п.1
5. отключить к-л. микросервис. работают только микросервисы, не св€занные с данным микросервисом
5.1 покликать по кнопкам. проверить очередь RabbitMQ - должны застр€ть соотв. запросы
6. включить микросервис из п.5. приложение полностью восстановитс€. из очереди RabbitMQ уйдут застр€вшие запросы

# текущее состо€ние проекта
при падении сервиса ShoppingCart падают все остальные сервисы

јрхитектура: в файле architecture.drawio


# загрузка рэббита
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:4-management - образ сам установитс€, потом запуститс€
или
1. скачать образ https://hub.docker.com/_/rabbitmq docker pull rabbitmq
2. docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:4-management