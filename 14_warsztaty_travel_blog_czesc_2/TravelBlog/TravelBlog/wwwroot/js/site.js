const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7187/weatherhub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
        //try {
        //    await connection.invoke("SendMessage", "user", "message");
        //} catch (err) {
        //    console.error(err);
        //}
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.on("ReceiveMessage", (user, message) => {
    console.log(user);
    console.log(message);
    const newP = document.createElement("p");
    newP.textContent = message;
    document.getElementById("weatherBox").appendChild(newP);
});

connection.onclose(async () => {
    await start();
});

// Start the connection.
start();
