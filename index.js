require('dotenv').config();
const express = require('express');
const axios = require('axios');
const port = process.env.PORT || 3000;

const app = express();

app.use(express.json())
app.use(express.urlencoded({ extended: true }));

app.get('/', function (req, res) {

    axios({
        url: `https://graph.facebook.com/utc2hcmc/posts?access_token=${process.env.TOKEN}`
    }).then(response => {
        const resdata = response.data;
        const fbdata = resdata.data;

        let output = {};
        for (let i = 0; i < 3; i++) {
            const element = fbdata[i];
            output[`bai${i+1}`] = {
                content: element.message
            };
        }
        console.log(output)
        res.send(JSON.stringify(output), null, 4)
    })
})

app.listen(port, function () {
    console.log('Your app running on port ' + port);
})