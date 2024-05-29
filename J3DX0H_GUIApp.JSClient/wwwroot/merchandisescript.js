let merchandises = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62997/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("MerchandiseCreated", (user, message) => {
        getdata();
    });

    connection.on("MerchandiseDeleted", (user, message) => {
        getdata();
    });
    connection.on("MerchandiseUpdate", (user, message) => {
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
    await fetch('http://localhost:62997/merchandise')
        .then(x => x.json())
        .then(y => {
            merchandises = y;
            //console.log(merchandises);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    merchandises.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.Id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:62997/merchandise/' + id, {
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
    let name = document.getElementById('merchandisename').value;
    fetch('http://localhost:62997/merchandise', {
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
function myFunc2() {
    location.replace("album.html")
}

function myFunc4() {
    location.replace("recordcompany.html")
}