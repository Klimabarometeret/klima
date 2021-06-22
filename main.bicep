module stacc 'storage.bicep' = {
  name: 'storageDeploy'
  params: {
    storageAccountName: 'stg${uniqueString(resourceGroup().id)}'
  }
}
