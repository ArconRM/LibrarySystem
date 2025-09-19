# Документация API

## Базовый URL
```

http://localhost:5057/api

````

**База данных** - Postgres, подключение настроено в appsettings.

#### Коды ответов

| Статус              | Описание                | Пример                                                                                    |
| ------------------- | ----------------------- | ----------------------------------------------------------------------------------------- |
| **200 OK**          | Книга успешно добавлена | `{ "uuid": "guid", "title": "War and Peace", "author": "Leo Tolstoy", "genre": "Novel" }` |
| **409 Conflict**    | Нарушение бизнес-правил | `{ "message": "..." }`                                                                    |
| **400 Bad Request** | Некорректные вводные данные | `{ "message": "Invalid data" }`                                                       |

---

## BookController

### **POST** `/Book/AddNewBook`

Добавляет новую книгу в каталог.

#### Пример тела запроса
```jsonc
{
  "genre": "string",
  "title": "string",
  "author": "string"
}
````

---

## UserController

### **POST** `/User/CreateUser`

Создаёт нового пользователя.

#### Пример тела запроса

```jsonc
{
  "fullName": "string",
  "email": "string",
  "phoneNumber": "string"
}
```

---

### **GET** `/User/GetAllUsers`

Получает список всех пользователей.

#### Пример ответа

```jsonc
[
  {
    "uuid": "guid",
    "fullName": "John Smith",
    "email": "john@example.com",
    "phoneNumber": "+1234567890"
  }
]
```

---

### **GET** `/User/GetUserWithAllInfo?uuid={guid}`

Возвращает пользователя со всей связанной информацией.


#### Пример ответа

```jsonc
{
  "uuid": "guid",
  "fullName": "John Smith",
  "subscription": {
    "startDate": "2025-09-19T13:30:00Z",
    "endDate": "2025-09-19T13:30:00Z",
    "price": 1000
  },
  "userBooks": [
    { "bookTitle": "War and Peace", "takenAt": "2025-09-19T13:30:00Z", "returnedAt": null }
  ]
}
```

---

### **PATCH** `/User/UpdateUser`

Обновляет данные пользователя.

#### Пример тела запроса

```jsonc
{
  "uuid": "guid",
  "fullName": "string",
  "email": "string",
  "phoneNumber": "string"
}
```

---

### **PATCH** `/User/SetUserSubscription`

Устанавливает или продлевает подписку пользователя.

#### Пример тела запроса

```jsonc
{
  "userUuid": "guid",
  "startDate": "2025-09-19T09:37:01.263Z",
  "endDate": "2025-10-19T09:37:01.263Z",
  "price": 1000
}
```

---

### **DELETE** `/User/DeleteUser?uuid={guid}`

Удаляет пользователя.

---

## UserBookController

### **POST** `/UserBook/AddUserBook`

Выдаёт книгу пользователю.

#### Пример тела запроса

```jsonc
{
  "userUuid": "guid",
  "bookUuid": "guid"
}
```

---

### **DELETE** `/UserBook/ReturnUserBook`

Возвращает книгу.

#### Пример тела запроса

```jsonc
{
  "userUuid": "guid",
  "bookUuid": "guid"
}
```

---

## Общие моменты

* Все запросы принимают **CancellationToken**.
* **UUID** — это стандартный `Guid`.

