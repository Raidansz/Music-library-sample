// albums.js

const apiUrl = "http://localhost:4671/api/Album";

class AlbumsViewModel {
    constructor() {
        this.albums = [];
        this.selectedAlbum = null;
        this.name = "";

        this.getAlbums();

        this.addAlbumCommand = {
            execute: () => {
                const newAlbum = { Name: this.name };
                fetch(apiUrl, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(newAlbum),
                })
                    .then((response) => response.json())
                    .then((data) => {
                        this.albums.push(data);
                    });
            },
            canExecute: () => this.name !== "",
        };

        this.updateAlbumCommand = {
            execute: () => {
                const updatedAlbum = { ...this.selectedAlbum, Name: this.name };
                fetch(apiUrl, {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(updatedAlbum),
                })
                    .then((response) => response.json())
                    .then((data) => {
                        const index = this.albums.findIndex((a) => a.Id === data.Id);
                        if (index !== -1) {
                            this.albums.splice(index, 1, data);
                        }
                    });
            },
            canExecute: () => this.selectedAlbum !== null && this.name !== "",
        };

        this.deleteAlbumCommand = {
            execute: () => {
                fetch(`${apiUrl}/${this.selectedAlbum.Id}`, {
                    method: "DELETE",
                })
                    .then((response) => response.json())
                    .then(() => {
                        const index = this.albums.findIndex((a) => a.Id === this.selectedAlbum.Id);
                        if (index !== -1) {
                            this.albums.splice(index, 1);
                        }
                    });
            },
            canExecute: () => this.selectedAlbum !== null,
        };
    }

    getAlbums() {
        fetch(apiUrl)
            .then((response) => response.json())
            .then((data) => {
                this.albums = data;
            });
    }
}

const viewModel = new AlbumsViewModel();
// Bind the view model to your HTML or UI framework
