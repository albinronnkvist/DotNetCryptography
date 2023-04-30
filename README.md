Cryptography in .NET using Symmetric encryption(AES), Asymmetric encryption(RSA) and Hashing algorithms(SHA)

# Symmetric encryption (AES)

Symmetric encryption is a type of cryptography where a single secret key is used for both encryption and decryption of data.
The algorithms are generally fast and efficient, making them suitable for encrypting large amounts of data. 
There are also scenarios where it's not preferred, especially when you need to exchange the secret key between multiple parties, 
which can be challenging to do securely. 

AES (Advanced Encryption Standard) is a widely-used symmetric encryption algorithm available through the [System.Security.Cryptography](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-8.0) namespace in .NET. 
It's for example used in [Azure Storage](https://learn.microsoft.com/en-us/azure/storage/common/storage-service-encryption) to encrypt data at rest.

In our _FilesController_, AES is used to encrypt and decrypt files.

- **Key**: A 128-bit encryption key is utilized for an optimal balance between security and performance. 
For enhanced security, consider using a 192-bit or 256-bit key. 
It is crucial to keep the **Key** confidential, as anyone with access to it can decrypt the data.
```
"AesEncryptionOptions": {
  "EncryptionKey": "3F52D15C8F7142DAA2E94B1E5C1B4617" // keep this in secrets.json / some key vault
}
```
- **IV**: Each file is assigned a unique, random 128-bit Initialization Vector (**IV**). 
The **IV**, in combination with the **Key**, establishes an unpredictable starting point for the encryption process. 
As a result, identical plaintext encrypted with the same key generates different ciphertexts, making it more difficult for an attacker to uncover patterns. 
While the **Key** must remain secret, the **IV** does not share the same requirement. But it must be stored alongside the file since it will be used during decryption.

# Asymmetric encryption (RSA)

WIP

# Hashing algorithms (SHA)

WIP
