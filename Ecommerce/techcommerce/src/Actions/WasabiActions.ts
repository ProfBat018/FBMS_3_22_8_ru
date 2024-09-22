// s3Client.ts
import AWS from 'aws-sdk';

const s3 = new AWS.S3({
    endpoint: 'https://s3.wasabisys.com', // Укажите ваш endpoint
    accessKeyId: '58G3DKL4MPZDHHQT9VO9', // Ваш Access Key
    secretAccessKey: '58G3DKL4MPZDHHQT9VO9', // Ваш Secret Key
    region: 'us-east-1', // Укажите ваш регион
});



export default s3;


