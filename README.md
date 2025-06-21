# URLShorten
---

## For Project Url - https://roadmap.sh/projects/url-shortening-service

---

# 📎 URL Shortener API Documentation

**Base URL**: `https://localhost:50415/`

## 📋 Overview

This API provides functionality for creating, managing, and tracking shortened URLs.

---

## 🔗 API Endpoints

### 1. ✅ Health Check

- **Method**: `GET`
- **URL**: `/api/shorten/helth`
- **Description**: Checks if the service is running and healthy.

```http
GET /api/shorten/helth
```

#### Response
```json

Service is running

````
---

### 2. 📄 Get All Shortened URLs

* **Method**: `GET`
* **URL**: `/api/shorten/all`
* **Description**: Retrieves a list of all shortened URLs.

#### Example

```http
GET /api/shorten/all
```

#### Response

```json
[
    {
        "id": 1,
        "url": "https://www.youtube.com/watch?v=V-K6haaZJr8&list=RDMM&index=14",
        "shortCode": "PLDPVgWx3Qg",
        "createdAt": "2025-06-21T20:51:04.5886737Z",
        "updatedAt": null
    }
]
```

---

### 3. 🔍 Get Original URL from Short URL

* **Method**: `GET`
* **URL**: `/api/shorten/{shortUrl}`
* **Description**: Redirects to or returns the original URL for the given short code.

#### Example

```http
GET /api/shorten/abc123
```

#### Response

```json
{
    "id": 1,
    "url": "https://www.youtube.com/watch?v=V-K6haaZJr8&list=RDMM&index=14",
    "shortCode": "RsvcEQax3Qg",
    "createdAt": "2025-06-21T20:56:18.4085179Z",
    "updatedAt": null
}
```

---

### 4. 📊 Get Stats of a Short URL

* **Method**: `GET`
* **URL**: `/api/shorten/{shortUrl}/stats`
* **Description**: Returns analytics information about a specific short URL.

#### Example

```http
GET /api/shorten/abc123/stats
```

#### Response

```json
{
    "id": 1,
    "url": "https://www.youtube.com/watch?v=V-K6haaZJr8&list=RDMM&index=14",
    "shortCode": "4g08mgmx3Qg",
    "createdAt": "2025-06-21T21:21:35.6932275Z",
    "updatedAt": null,
    "accessCount": 6,
    "graphData": [
        {
            "date": "2025-06-21",
            "hits": 6
        }
    ]
}
```

---

### 5. ➕ Create a Short URL

* **Method**: `POST`
* **URL**: `/api/shorten`
* **Description**: Creates a new short URL.

#### Example

```http
POST /api/shorten
```

#### Request Body

```json
{
  "url": "https://example.com/very/long/url"
}
```

#### Response

```json
{
    "id": 1,
    "url": "https://www.youtube.com/watch?v=V-K6haaZJr8&list=RDMM&index=14",
    "shortCode": "4g08mgmx3Qg",
    "createdAt": "2025-06-21T21:21:35.6932275Z",
    "updatedAt": null
}
```

---

### 6. 🔄 Update a Short URL

* **Method**: `PUT`
* **URL**: `/api/shorten/{shortUrl}`
* **Description**: Updates the original URL mapped to a given short URL.

#### Example

```http
PUT /api/shorten/xBibOgGx3Qg
```

#### Request Body

```json
{
  "url": "https://example.com/new-target-url"
}
```

#### Response

```json
{
    "id": 1,
    "url": "https://dev.to/ravivis13370227/emailspamchecker-class-for-net-framework-47-59h8",
    "shortCode": "xBibOgGx3Qg",
    "createdAt": "2025-06-21T20:21:39.2808452Z",
    "updatedAt": "2025-06-21T20:24:39.7940712Z"
}
```

---

### 7. ❌ Delete a Short URL

* **Method**: `DELETE`
* **URL**: `/api/shorten/{shortUrl}`
* **Description**: Deletes a short URL from the system.

#### Example

```http
DELETE /api/shorten/abc123
```

#### Response

```json
{
  "message": "Short URL deleted successfully."
}
```

---

## 🧪 Example Short URL Flow

1. User posts an original URL → receives a short code.
2. User accesses short code → gets redirected.
3. User views stats → sees click count and last access time.

---

## 🛠 Common Errors

| Code | Description           |
| ---- | --------------------- |
| 400  | Bad Request           |
| 404  | Short URL Not Found   |
| 500  | Internal Server Error |

---

## 📅 Date Format

* All timestamps are in UTC.
* Format: `YYYY-MM-DDTHH:mm:ssZ`

---

## 🔐 Authentication

Currently, no authentication is required.
Authentication can be added using API keys, JWT, or OAuth in the future.

---

## 📫 Contact

For issues, contact: \[[Email](mailto:vv5845055@gmail.com)]

