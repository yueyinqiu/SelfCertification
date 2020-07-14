# SelfCertification
This project helps you identify me.  
It means that you can check whether a file is published by me or not.

## How is it implemented?
It's a very easy process.  But if you don't learn something about the asymmetric cryptography, it may still confuse you. In that case, you can just skip this part.  
Compute the hash value of the file first(md5). Then just sign the hash by my private key(RSA). Now everything has been done.  
You can compute the hash, then verify it by the signature with the public key. If they match, the file should be published by me.

## How to use this project?
You just need to use 'CertificationChecker', and 'SelfCertification' should be used by myself.

To produce the signature:
- First, I have such a file to publish.  
- Then I will use 'SelfCertification', enter my private key path and the file path.  
- It will produce a signature file soon.  
- I will just publish the signature file together.

To check the signature:
- Use 'CertificationChecker', enter the public key path (you can get my public key [here](//github.com/yueyinqiu/SelfCertification/blob/master/MYPUBLICKEY)), the file path and the signature path.
- It will tell you whether the three file matches soon.