# Sample Device Address API Skill

The Alexa API provides endpoints to retrieve address information from users provided they have given permissions to the skill to access this information. This sample skill demonstrates how to use the built in Device Address Service Client to retrieve the user's address information and ensure they have set proper permissions before doing so. By default the user will have permissions disabled, the skill can send a card to the user's Alexa app which will ask them to enable the permission and will show them the exact information they are providing.

There are two options to retrieve address information: Full Address and Short Address.

Full Address
```
    public class Address
    {
        string AddressLine1 
        string AddressLine2
        string AddressLine3
        string CountryCode
        string StateOrRegion
        string City
        string DistrictOrCounty
        string PostalCode
    }
```

Short Address
```
    public class ShortAddress
    {
        string CountryCode
        string PostalCode
    }
```

This sample is based on the [NodeJS Sample Device Address Skill](https://github.com/alexa/skill-sample-node-device-address-api)