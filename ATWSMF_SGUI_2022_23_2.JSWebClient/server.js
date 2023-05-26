'use strict';
const http = require('http');
const fs = require('fs');
const path = require('path');
const port = process.env.PORT || 1337;

const server = http.createServer(function (req, res) {
    // Enable CORS headers
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, DELETE');
    res.setHeader('Access-Control-Allow-Headers', 'Content-Type');

    // Handle preflight OPTIONS request
    if (req.method === 'OPTIONS') {
        res.writeHead(204);
        res.end();
        return;
    }

    // Serve static files
    if (req.url === '/' || req.url === '/index.html') {
        fs.readFile(path.join(__dirname, 'index.html'), 'utf8', function (err, content) {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/plain' });
                res.end('Internal Server Error');
            } else {
                res.writeHead(200, { 'Content-Type': 'text/html' });
                res.end(content);
            }
        });
    } else if (req.url === '/song.html') {
        fs.readFile(path.join(__dirname, 'song.html'), 'utf8', function (err, content) {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/plain' });
                res.end('Internal Server Error');
            } else {
                res.writeHead(200, { 'Content-Type': 'text/html' });
                res.end(content);
            }
        });
    } else if (req.url === '/album.html') {
        fs.readFile(path.join(__dirname, 'album.html'), 'utf8', function (err, content) {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/plain' });
                res.end('Internal Server Error');
            } else {
                res.writeHead(200, { 'Content-Type': 'text/html' });
                res.end(content);
            }
        });
    } else if (req.url === '/artists.html') {
        fs.readFile(path.join(__dirname, 'artists.html'), 'utf8', function (err, content) {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/plain' });
                res.end('Internal Server Error');
            } else {
                res.writeHead(200, { 'Content-Type': 'text/html' });
                res.end(content);
            }
        });
    } else if (req.url.startsWith('/api')) {
        // Handle API routes for CRUD operations
        // Implement your API route handling logic here
    } else {
        // Handle other routes (e.g., CSS, JavaScript files)
        const filePath = path.join(__dirname, 'public', req.url);
        fs.readFile(filePath, function (err, content) {
            if (err) {
                res.writeHead(404, { 'Content-Type': 'text/plain' });
                res.end('File Not Found');
            } else {
                const ext = path.extname(filePath);
                const contentType = getContentType(ext);
                res.writeHead(200, { 'Content-Type': contentType });
                res.end(content);
            }
        });
    }


});

server.listen(port, function () {
    console.log(`Server running on port ${port}`);
});

function getContentType(ext) {
    switch (ext) {
        case '.html':
            return 'text/html';
        case '.css':
            return 'text/css';
        case '.js':
            return 'text/javascript';
        default:
            return 'text/plain';
    }
}




































//'use strict';
//const http = require('http');
//const fs = require('fs');
//const path = require('path');
//const port = process.env.PORT || 1337;

//const server = http.createServer(function (req, res) {
//    // Serve static files
//    if (req.url === '/') {
//        fs.readFile(path.join(__dirname, 'index.html'), 'utf8', function (err, content) {
//            if (err) {
//                res.writeHead(500, { 'Content-Type': 'text/plain' });
//                res.end('Internal Server Error');
//            } else {
//                res.writeHead(200, { 'Content-Type': 'text/html' });
//                res.end(content);
//            }
//        });
//    } else if (req.url.startsWith('/api')) {
//        // Handle API routes for CRUD operations
//        // Implement your API route handling logic here
//    } else {
//        // Handle other routes (e.g., CSS, JavaScript files)
//        const filePath = path.join(__dirname, 'public', req.url);
//        fs.readFile(filePath, function (err, content) {
//            if (err) {
//                res.writeHead(404, { 'Content-Type': 'text/plain' });
//                res.end('File Not Found');
//            } else {
//                const ext = path.extname(filePath);
//                const contentType = getContentType(ext);
//                res.writeHead(200, { 'Content-Type': contentType });
//                res.end(content);
//            }
//        });
//    }
//});

//server.listen(port, function () {
//    console.log(`Server running on port ${port}`);
//});

//function getContentType(ext) {
//    switch (ext) {
//        case '.html':
//            return 'text/html';
//        case '.css':
//            return 'text/css';
//        case '.js':
//            return 'text/javascript';
//        default:
//            return 'text/plain';
//    }
//}
