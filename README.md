# URLShorten

# 📎 URL Shortener API Documentation

Base URL: `https://localhost:50415/`

## 📋 Overview

This API allows users to create, retrieve, update, delete, and track short URLs.

---

## 🔗 Endpoints

### 1. ✅ Health Check

- **Method**: `GET`
- **Endpoint**: `/api/shorten/helth`
- **Description**: Check if the API is running.

---

### 2. 📄 Get All Shortened URLs

- **Method**: `GET`
- **Endpoint**: `/api/shorten/all`
- **Description**: Retrieve a list of all shortened URLs.

---

### 3. 🔍 Get Original URL from Short URL

- **Method**: `GET`
- **Endpoint**: `/api/shorten/{shortUrl}`
- **Description**: Redirects or returns the original URL corresponding to the given short URL.

#### Example:
```http
GET /api/shorten/abc123
