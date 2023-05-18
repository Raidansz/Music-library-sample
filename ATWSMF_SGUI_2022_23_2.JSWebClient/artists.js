// artists.js

const apiUrl = "http://localhost:4671/api/Artist";

class ArtistsViewModel {
    constructor() {
        this.artists = [];
        this.selectedArtist = null;
        this.name = "";

        this.getArtists();

        this.addArtistCommand = {
            execute: () => {
                const newArtist = { Name: this.name };
                fetch(apiUrl, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(newArtist),
                })
                    .then((response) => response.json())
                    .then((data) => {
                        this.artists.push(data);
                    });
            },
            canExecute: () => this.name !== "",
        };

        this.updateArtistCommand = {
            execute: () => {
                const updatedArtist = { ...this.selectedArtist, Name: this.name };
                fetch(apiUrl, {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(updatedArtist),
                })
                    .then((response) => response.json())
                    .then((data) => {
                        const index = this.artists.findIndex((a) => a.Id === data.Id);
                        if (index !== -1) {
                            this.artists.splice(index, 1, data);
                        }
                    });
            },
            canExecute: () => this.selectedArtist !== null && this.name !== "",
        };

        this.deleteArtistCommand = {
            execute: () => {
                fetch(`${apiUrl}/${this.selectedArtist.Id}`, {
                    method: "DELETE",
                })
                    .then((response) => response.json())
                    .then(() => {
                        const index = this.artists.findIndex((a) => a.Id === this.selectedArtist.Id);
                        if (index !== -1) {
                            this.artists.splice(index, 1);
                        }
                    });
            },
            canExecute: () => this.selectedArtist !== null,
        };
    }

    getArtists() {
        fetch(apiUrl)
            .then((response) => response.json())
            .then((data) => {
                this.artists = data;
            });
    }
}

const viewModel = new ArtistsViewModel();
// Bind the view model to your HTML or UI framework
