$.ajax({

    url: "/Home/Repos",
    dataType: "json",
    method: "GET",
    success: function (data) {
        setRepos(data);
        //console.log(data);
        //$("<ul>").attr("id", "repolist").appendTo("body");
        //data.forEach((repo) => {
            //$("<li>").text(repo.name).appendTo("#repolist")
        //});

    }
})

function setRepos(data) {
    for (var i = 0; i < data.length; i++) {
        console.log(data[i]);
    }



}