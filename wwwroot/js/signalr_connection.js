// configure the connection to the hub 
var userConnection = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").withAutomaticReconnect().build();

// listen to the event coming from the server

userConnection.on("onNewUserRecieved", (userCount) => {
    let counter = document.getElementById("userViewCounter");
    counter.innerText = userCount;
});
userConnection.on("onVotesRecieved", (cloakVote, stoneVote, wandVote) => {
    let cloakVoteCounter = document.getElementById("cloakVoteCounter");
    let stoneVoteCounter = document.getElementById("stoneVoteCounter");
    let wandVoteCounter = document.getElementById("wandVoteCounter");

    cloakVoteCounter.innerText = cloakVote;
    stoneVoteCounter.innerText = stoneVote;
    wandVoteCounter.innerText = wandVote;
});

// Call the method of the server to notify the server that we have connected

function fullfiled() {
    console.log("connection has been established !!");
    userConnection.send("OnNewUserConnected");
}
function rejected() {
    console.log("connection to the hub failed !!");
}

// Start the connection from the server

userConnection.start().then(fullfiled, rejected);