// songs.js

const apiUrl = "http://localhost:4671/api/Song";

class SongsViewModel {
    constructor() {
        this.songs = [];
        this.selectedSong = null;
        this.name = "";

        this.getSongs();

        this.addSongCommand = {
            execute: () => {
                const newSong = { Name: this.name };
                fetch(apiUrl, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(newSong),
                })
                    .then((response) => response.json())
                    .then((data) => {
                        this.songs.push(data);
                    });
            },
            canExecute: () => this.name !== "",
        };

        this.updateSongCommand = {
            execute: () => {
                const updatedSong = { ...this.selectedSong, Name: this.name };
                fetch(apiUrl, {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(updatedSong),
                })
                    .then((response) => response.json())
                    .then((data) => {
                        const index = this.songs.findIndex((s) => s.Id === data.Id);
                        if (index !== -1) {
                            this.songs.splice(index, 1, data);
                        }
                    });
            },
            canExecute: () => this.selectedSong !== null && this.name !== "",
        };

        this.deleteSongCommand = {
            execute: () => {
                fetch(`${apiUrl}/${this.selectedSong.Id}`, {
                    method: "DELETE",
                })
                    .then((response) => response.json())
                    .then(() => {
                        const index = this.songs.findIndex((s) => s.Id === this.selectedSong.Id);
                        if (index !== -1) {
                            this.songs.splice(index, 1);
                        }
                    });
            },
            canExecute: () => this.selectedSong !== null,
        };
    }

    getSongs() {
        fetch(apiUrl)
            .then((response) => response.json())
            .then((data) => {
                this.songs = data;
            });
    }
}

const viewModel = new SongsViewModel();
// Bind the view model to your HTML or UI framework
