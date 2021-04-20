axios.get('https://graph.facebook.com/5951071092letranxuanson/posts?fields=likes.summary(true),comments,message&access_token=')
        .then(response => {
            const data = response.data.data;
            var output = "";
            for (let i = 0; i < 3; i++) {
                const element = data[i];
                output += `<span class='contain'>Bài viết số ${i+1}</span></br><p> -Nội dung: ${element.message}</p><p> -Số lượt thích: ${element.likes.summary.total_count}</br></br>`
            }
            document.getElementById('main').innerHTML = output;
        })
        .catch(error => console.error(error));