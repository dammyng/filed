# Filed Coding Challenge

---
A simple web service to process payment

## Build and install dependencies

```shell
    $ dotnet restore
```

## Start application locally

```shell
    $ dotnet run
```

## Sample call and response

---

```shell
    curl --location --request POST 'http://localhost:5000/ProcessPayment' \
    --header 'Content-Type: application/json' \
    --data-raw '{
    "creditCardNumber": "CCCC CCCC CCCC CCCC CCC",
    "cardHolder": "FOO BAR",
    "expirationDate": "2028-02-22",
    "securityCode": "123",
    "amount": 240.0
    }'
```

---

```
   Payment is Processed 
```


## Run on docker

```shell
    $ docker build -t filedapi .
    $ docker run -d -p 8080:80 --name filed filedapi
```

`service available at http://localhost:8080/ProcessPayment`


## Limitations and Assumptions

- A system in production should grant more flexibility with possible response

- There could have more possible response than stated in the exercise documentation - the document does not provision for pending payments.

- Payment gateway availability is returned at random.

- Demo status are returned on every call.
 