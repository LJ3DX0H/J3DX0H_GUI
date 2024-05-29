let recordCompanies = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62997/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RecordCompanyCreated", (user, message) => {
        getdata();
    });

    connection.on("RecordCompanyDeleted", (user, message) => {
        getdata();
    });
    
    connection.on("RecordCompanyUpdate", (user, message) => {
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
    await fetch('http://localhost:62997/recordcompany')
        .then(x => x.json())
        .then(y => {
            recordCompanies = y;
            //console.log(recordCompanies);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    recordCompanies.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.Id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:62997/recordcompany/' + id, {
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
    let name = document.getElementById('rcname').value;
    fetch('http://localhost:62997/recordcompany', {
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
function myFunc3() {
    location.replace("merchandise.html")
}
