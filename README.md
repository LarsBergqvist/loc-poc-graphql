# loc-poc-graphql

# query
```
{ locations  {
  name, description, latitude, longitude, id
}}
```
# mutation
```
mutation($location: locationInput!) {
  createLocation(location: $location) { id name latitude longitude }
}
```
# subscription
```
subscription {
  locationAdded { id, name }
}
```
