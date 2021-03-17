# NotePadServerAPI
## Описание - суть, идея, замысел

Backend:
[ASP.NET Core](https://dotnet.microsoft.com/learn/aspnet/what-is-aspnet-core)

Database:
[MySQL](https://www.mysql.com/)

Сервис "Покупки", который может хранить данные о покупках разных людей.

О покупке необходимо хранить следующую информацию:
- Дата покупки
- Название товара
- Сумму, потраченную на товар

Необходима базовая концепция аутентификации. Например, можно передавать ID человека, про которого запрашивается/отправляется информация через строку запроса, или заголовок.

На данном уровне подразумевается, что сервис является "записной книжкой", в которую человек может поместить информацию о своих покупках.

## Инструкция по запуску

Подробная инструкция по запуску: какие SDK нужны, на какой ОС можно запустить и все необходимое для самостоятельного запуска вашего проекта из исходного кода

Можно запустить на Windows.

Нужны: [Docker Desktop](https://www.docker.com/products/docker-desktop), [Visual Studio](https://visualstudio.microsoft.com/ru/downloads/)

Для запуска нужно скачать проект и зайти через cmd в папку проекта (там где находится docker-compose файл).
В консоли ввести следующие команды:
```sh
docker-compose pull
docker-compose up -d
```
После открываем любой браузер и вводим в поле для ссылок:
```sh
localhost:8080/swagger
```
Там можно будет познакомиться с документацией и попробовать отправить запросы.

Или же вручную, примеры:
```sh
localhost:8080/api/users
localhost:8080/api/users/{userId}
localhost:8080/api/users/{userId}/{purchaseId}
```

## Ссылки

[Видео](https://drive.google.com/file/d/10ueATeOIKKSSh2JCmqt4PvzoQR1hESB6/view?usp=sharing)

[Dockerhub repo](https://hub.docker.com/repository/docker/nomxd/serverapiimg)

[Postman tests](https://www.getpostman.com/collections/bfcf4a9c532ce3a12a1f)
