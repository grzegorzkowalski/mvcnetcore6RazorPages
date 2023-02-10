const connection = new signalR.HubConnectionBuilder()
    .withUrl("/weatherhub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.on("ReceiveMessage", (user, message) => {
    console.log(user);
    console.log(message);
    //const li = document.createElement("li");
    //li.textContent = `${user}: ${message}`;
    //document.getElementById("messageList").appendChild(li);
});

connection.onclose(async () => {
    await start();
});

// Start the connection.
start();

document.querySelector("#weatherButton").addEventListener("click", function () {
    let weather = document.querySelector("#weatherInput").value;
    try {
        async function send() { await connection.invoke("SendMessage", "user", weather) };
        send();
    } catch (err) {
        console.error(err);
    }
});