<h2>Krypto</h2>
Krypto is trivial implementation of basic encryption methods.

<h2>Introduction</h2>
Krypto was created as a simple tool to test every kind of encryption method and how to decrypt them. It supports text, file (.txt) and binary.

<h2>Technologies</h2>
- <strong>.NET WPF</strong>: Platform used to build window app, that allows this app to be intuitive.

<h2>Supported cryptor methods</h2>
- <strong>Transposition cipher</strong>: Changes the input text to cross joined every letter of sentence as words, separated with '!' char. <br>
- <strong>Monoalphabetic cipher</strong>: Changes each character in the entered text to a value one key larger in ASCII code.<br>
- <strong>Polyalphabetic cipher</strong>: Changes each character in the entered text to be one character away from the same key position within the ASCII encoding. <br>
- <strong>Base64</strong>: Changes text to be corresponding in BASE64 encoding. <br>
- <strong>DES</strong>: Uses build-in DES method in CBC mode with PKCS7 padding.<br>
- <strong>RC4</strong>: Encrypts data by combining a variable-length key with the plaintext through a process of bitwise XOR, generating a stream of pseudorandom bytes. These bytes are then XORed with the plaintext to produce the ciphertext, providing confidentiality to the data. <br>
- <strong>RSA</strong>: Secures data by using a pair of mathematically related keys – a public key for encryption and a private key for decryption. <br>
- <strong>Hamming</strong>: Hamming coding involves adding redundant bits to data to enable error detection and correction, ensuring that the total number of bits in the encoded message satisfies 2^r >= m + r + 1, where r is the number of redundant bits and m is the number of data bits.<br>
