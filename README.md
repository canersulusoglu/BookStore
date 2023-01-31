# BookStore Assignment-1

## Environment

- Used Framework is [.NET 7](https://github.com/dotnet).

##### To install packages
```console
cd ./WebAPI
dotnet restore 
```

##### To run
```console
cd ./WebAPI
dotnet run 
```

##### To run with hot-reload
```console
cd ./WebAPI
dotnet watch 
```

## API Endpoints

<details>
 <summary>
 <code>GET</code> 
 <code><b>/Books</b></code> 
 <code>Gets all books.</code>
</summary>

##### Parameters
None
##### Responses
| http code     | content-type                      | response                                                            |
|---------------|-----------------------------------|---------------------------------------------------------------------|
| `200`         | `application/json;charset=UTF-8`  | Array of books.                                                     |
---
</details>

<details>
 <summary>
 <code>POST</code> 
 <code><b>/Books</b></code> 
 <code>Add new book.</code>
</summary>

##### Parameters
None
##### Request Body
```json
{
    "title": "string",
    "genreId": 1,
    "pageCount": 0,
    "publishDate": "2023-01-29T20:36:53.302Z"
}
```
##### Responses
| http code     | content-type                      | response                                                            |
|---------------|-----------------------------------|---------------------------------------------------------------------|
| `200`         |                                   |                                                                     |
| `400`         | `text/plain;charset=UTF-8`        | Book is already exists.                                             |
---
</details>

<details>
 <summary>
 <code>GET</code> 
 <code><b>/Books{id}</b></code> 
 <code>Gets one book by id.</code>
</summary>

##### Parameters
| name   |  type      | data type      | description                                          |
|--------|------------|----------------|------------------------------------------------------|
|  `id`  |  required  | integer($int32)| Book unique id number                                |
##### Responses
| http code     | content-type                      | response                                                            |
|---------------|-----------------------------------|---------------------------------------------------------------------|
| `200`         | `application/json;charset=UTF-8`  | Book.                                                               |
| `400`         | `text/plain;charset=UTF-8`        | Book is not exists.                                                 |
---
</details>

<details>
 <summary>
 <code>GET</code> 
 <code><b>/Books/filter</b></code> 
 <code>Filters and orders books.</code>
</summary>

##### Parameters
| name            |  type      | data type         | description                                          |
|-----------------|------------|-------------------|------------------------------------------------------|
|`Title`          |  optional  | string            | Book title.                                          |
|`MinPageCount`   |  optional  | integer($int32)   | Book minimum page count.                             |
|`MaxPageCount`   |  optional  | integer($int32)   | Book maximum page count.                             |
|`PublishDateFrom`|  optional  | string($date-time)| Book publish date start.                             |
|`PublishDateTo`  |  optional  | string($date-time)| Book publish date end.                               |
|`OrderBy`        |  optional  | string            | Orders filtered books.                               |
##### Responses
| http code     | content-type                      | response                                                            |
|---------------|-----------------------------------|---------------------------------------------------------------------|
| `200`         |                                   |                                                                     |
| `400`         | `text/plain;charset=UTF-8`        | Book is not exists.                                                 |
---
</details>

<details>
 <summary>
 <code>PUT</code> 
 <code><b>/Books{id}</b></code> 
 <code>Updates book by id.</code>
</summary>

##### Parameters
 | name   |  type      | data type      | description                                          |
 |--------|------------|----------------|------------------------------------------------------|
 |  `id`  |  required  | integer($int32)| Book unique id number                                |
##### Request Body
```json
{
    "title": "string",
    "genreId": 1,
    "pageCount": 0,
    "publishDate": "2023-01-29T20:36:53.302Z"
}
```
##### Responses
| http code     | content-type                      | response                                                            |
|---------------|-----------------------------------|---------------------------------------------------------------------|
| `200`         |                                   |                                                                     |
| `400`         | `text/plain;charset=UTF-8`        | Book is not exists.                                                 |
---
</details>

<details>
 <summary>
 <code>PATCH</code> 
 <code><b>/Books{id}</b></code> 
 <code>Updates book by id with patch operations.</code>
</summary>

##### Parameters
| name   |  type      | data type      | description                                          |
|--------|------------|----------------|------------------------------------------------------|
|  `id`  |  required  | integer($int32)| Book unique id number                                |
##### Request Body
```json
[
    {
        "path": "/Title",
        "op": "replace",
        "value": "NewTitle"
    },
]
```
##### Responses
| http code     | content-type                      | response                                                            |
|---------------|-----------------------------------|---------------------------------------------------------------------|
| `200`         |                                   |                                                                     |
| `400`         | `text/plain;charset=UTF-8`        | Book is not exists.                                                 |
---
</details>

<details>
 <summary>
 <code>DELETE</code> 
 <code><b>/Books{id}</b></code> 
 <code>Deletes book by id.</code>
</summary>

##### Parameters
| name   |  type      | data type      | description                                          |
|--------|------------|----------------|------------------------------------------------------|
|  `id`  |  required  | integer($int32)| Book unique id number                                |
##### Responses
| http code     | content-type                      | response                                                            |
|---------------|-----------------------------------|---------------------------------------------------------------------|
| `200`         |                                   |                                                                     |
| `400`         | `text/plain;charset=UTF-8`        | Book is not exists.                                                 |
---
</details>