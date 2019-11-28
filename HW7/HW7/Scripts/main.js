$(document).ready(function () {
    $.ajax({

        url: "/Home/Repos",
        dataType: "json",
        method: "GET",
        error: errorinajax,
        success: function (data) {
            setRepos(data);
            //console.log(data);
            //$("<ul>").attr("id", "repolist").appendTo("body");
            //data.forEach((repo) => {
            //$("<li>").text(repo.name).appendTo("#repolist")
            //});
        }
    });
})
function errorinajax() {
    console.log("error in ajax");
}
function setRepos(data) {
    //console.log makes sure I am getting the data that I need for all the repositories

    console.log(data);
    for (var i = 0; i < data.length; i++) {

        //This is a variable called repoName of type var(takes type of the value)
        // we are creating an Element <h3> 
        var repoName = document.createElement('a');

        //We are creating a variable called repoNameText and giving it the value of a name
        //We get this name from the data that Repos() from C# gives us.
        //This data is a list of repoInfo. Each repoInfo has a repoName. Therefore,
        //We grab ["repoName"] (which corresponds to the repoInfo class attribute)
        //from the [i] index/repository from our data
        var repoNameText = document.createTextNode(data[i]["repoName"]);

        //Adding the name of the current repository to the repoName element which is
        // an <h3> element
        repoName.append(repoNameText);

        //Adding the header repoName and its children (repoNameText) to the end of the 
        // element with the id of #repos
        repoName.href = data[i]["repoUrl"];
        $('#repos').append(repoName);


        var RepoOwner = document.createElement('h3');
        var RepoOwnerText = document.createTextNode(data[i]["repoOwner"]);
        RepoOwner.append(RepoOwnerText);
        $('#repos').append(RepoOwner);

        var RepoTime = document.createElement('h3');
        var RepoTimeText = document.createTextNode(data[i]["repoTime"]);
        RepoTime.append(RepoTimeText);
        $('#repos').append(RepoTime);

        var RepoProfile = document.createElement('img');
        //var firstRepoText = document.createTextNode(data["repoProfile"]);
        RepoProfile.src = data[i]["repoProfile"];
        RepoProfile.id = "repoimage";
        $('#repos').append(RepoProfile);
        $('#repos').append($('<button type="button" onclick="return setCommit(\'' + data[i].repoOwner + '\',\'' + data[i].repoName + '\')">Click Here</button>'));
    }
}

function setCommit(ownerName, repoName) {
    $.ajax({
        url: "/Home/Commits?owner=" + ownerName + "&repo=" + repoName,
        dataType: "json",
        method: "GET",
        error: errorinajax,
        success: showCommit
    });
}
function errorinajax() {
    console.log("error in ajax");
}
function showCommit(data) {
    console.log(data);
    $('#commitLists').empty();
    $("#rows").append($('<th>Sha</th>'));
    $("#rows").append($('<th>Date and Time</th>'));
    $("#rows").append($('<th>Committer Name</th>'));
    $("#rows").append($('<th>Commit Message</th>'));
    for (var i = 0; i < data.length; i++) {

        var commitSha = document.createElement('a');

        var commitShaText = document.createTextNode(data[i]["commitSha"]);

        commitSha.append(commitShaText);

        commitSha.href = data[i]["commitHtmlurl"];
        $('#commitLists').append(commitSha);



        var commitTimestamp = document.createElement('h3');
        var commitTimestampText = document.createTextNode(data[i]["commitTimestamp"]);
        commitTimestamp.append(commitTimestampText);
        $('#commitLists').append(commitTimestamp);

        var commitCommitter = document.createElement('h3');
        var commitCommitterText = document.createTextNode(data[i]["commitCommitter"]);
        commitCommitter.append(commitCommitterText);
        $('#commitLists').append(commitCommitter);

        var commitCommitmessage = document.createElement('h3');
        var commitCommitmessageText = document.createTextNode(data[i]["commitCommitmessage"]);
        commitCommitmessage.append(commitCommitmessageText);
        $('#commitLists').append(commitCommitmessage);





    }
}
