@minLength(3)
@maxLength(24)
param storageAccountName string
param location string = resourceGroup().location
param globalRedundancy bool = false

var containerName = 'ssbdata'

resource stacc 'Microsoft.Storage/storageAccounts@2021-04-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: globalRedundancy ? 'Standard_GRS' : 'Standard_LRS'
  }
  kind: 'StorageV2'
}

resource container1 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-04-01' = {
  name: '${stacc.name}/default/${containerName}'
}

param currentTime string = utcNow()
output storageId string = stacc.id
output storageName string = stacc.name
output blobEndpoint string = stacc.properties.primaryEndpoints.blob
output time string = currentTime
