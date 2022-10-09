# DESAFIO TÉCNICO: JUNTOS SOMOS +

A aplicação `jsmclients` foi desenvolvida para armazenar os pacotes de dados enviados e também permite a busca por clientes elegíveis.


## Endpoints

- `GET/api/Client/ElegibleList`

Procura e retorna uma lista de elegíveis de acordo com o tipo e a região informadas:

| Region | Type |
|:---|:---|
| `0`: norte | `0`: special |
| `1`: nordeste | `1`: normal |
| `2`: sul | `2`: laborious |
| `3`: sudeste |
| `4`: centro-oeste |


## Regras de Negócio

1. Clientes classificados de acordo com as cinco regiões do país.

2. Clientes rotulados como `special`, `normal` ou `laborious` de acordo com coordenadas informadas.

3. Adaptação dos contatos telefônicos para o formato `E.164`.

4. Nacionalidade padrão: BR.

5. Gênero formatado para um único caracter, `f` ou `m`.

6. Campo `age` removido.

7. Estrutura formatada conforme Output abaixo:

```json
{
  "type": "laborious"
  "gender": "m",
  "name": {
    "title": "mr",
    "first": "quirilo",
    "last": "nascimento"
  },
  "location": {
    "region": "sul"
    "street": "680 rua treze ",
    "city": "varginha",
    "state": "paraná",
    "postcode": 37260,
    "coordinates": {
      "latitude": "-46.9519",
      "longitude": "-57.4496"
    },
    "timezone": {
      "offset": "+8:00",
      "description": "Beijing, Perth, Singapore, Hong Kong"
    }
  },
  "email": "quirilo.nascimento@example.com",
  "birthday": "1979-01-22T03:35:31Z",
  "registered": "2005-07-01T13:52:48Z",
  "telephoneNumbers": [
    "+556629637520"
  ],
  "mobileNumbers": [
    "+553270684089"
  ],
  "picture": {
    "large": "https://randomuser.me/api/portraits/men/83.jpg",
    "medium": "https://randomuser.me/api/portraits/med/men/83.jpg",
    "thumbnail": "https://randomuser.me/api/portraits/thumb/men/83.jpg"
  },
  "nationality": "BR"
}
```


## Ferramentas

- .NET 5
- SQLite
- EFCore
- Swagger
