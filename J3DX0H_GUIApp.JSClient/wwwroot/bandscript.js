let bands = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62997/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BandCreated", (user, message) => {
        getdata();
    });

    connection.on("BandDeleted", (user, message) => {
        getdata();
    });
    connection.on("BandUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected");
    }
    catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:62997/band')
        .then(x => x.json())
        .then(y => {
            bands = y;
            //console.log(bands);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    bands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.bandId + "</td><td>"
            + t.Name + "</td><td>" +
            `<button type="button" onclick="remove(${t.bandId})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:62997/band/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('bandname').value;
    fetch('http://localhost:62997/band', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function myFunc1() {
    location.replace("album.html")
}
function myFunc3() {
    location.replace("merchandise.html")
}
function myFunc4() {
    location.replace("recordcompany.html")
}