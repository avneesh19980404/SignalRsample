// configure the connection to the hub 
var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/deathlyHollow").withAutomaticReconnect().build();

// listen to the event coming from the server

connection.on("onVotesRecieved", (cloakVote, stoneVote, wandVote) => {
    let cloakVoteCounter = document.getElementById("cloakVoteCounter");
    let stoneVoteCounter = document.getElementById("stoneVoteCounter");
    let wandVoteCounter = document.getElementById("wandVoteCounter");

    cloakVoteCounter.innerText = cloakVote;
    stoneVoteCounter.innerText = stoneVote;
    wandVoteCounter.innerText = wandVote;
});


// Call the method of the server to notify the server that we have connected

function fullfiled() {
    console.log("connection has been established with deathly hollow !!");
}
function rejected() {
    console.log("connection to the hub failed with deathly hollow !!");
}

// Start the connection from the server

connection.start().then(fullfiled, rejected);