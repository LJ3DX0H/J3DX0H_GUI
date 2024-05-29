let albums = [];
let connection = null;

let albumIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62997/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AlbumCreated", (user, message) => {
        getdata();
    });

    connection.on("AlbumDeleted", (user, message) => {
        getdata();
    });

    connection.on("AlbumUpdated", (user, message) => {
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
        console.log("SignalR Connected.");
    }
    catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:62997/album')
        .then(x => x.json())
        .then(y => {
            albums = y;
            //console.log(albums);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    albums.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.albumId + "</td><td>"
            + t.albumTitle + "</td><td>" +
            `<button type="button" onclick="remove(${t.albumId})">Delete</button>`
            + "</td></tr>";
            `<button type="button" onclick="showupdate(${t.albumId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:62997/album/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById("uformdiv").style.display = 'none';
    document.getElementById('albumtitletoupdate')).value = albums.find(t => t['id'] == id)['albumTitle'];
    document.getElementById('uformdiv').style.display = 'flex';
    albumIdToUpdate = id;

}

function create() {
    let name = document.getElementById('albumtitle').value;
    fetch('http://localhost:62997/album', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { albumTitle: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function update() {
    let name = document.getElementById('albumtitletoupdate').value;
    let id= 
    fetch('http://localhost:62997/album', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { albumTitle: name, id: albumtitletoupdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function myFunc2() {
    location.replace("band.html")
}
function myFunc3() {
    location.replace("merchandise.html")
}
function myFunc4() {
    location.replace("recordcompany.html")
}
