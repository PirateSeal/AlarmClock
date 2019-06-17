const start = function() {

    const PIXI = require('PIXI.js');
    const three = require('three');

    // Create the PIXI.js renderer
    const PIXIRenderer = PIXI.autoDetectRenderer(512, 512, { transparent: true });

    // Create the three.js renderer
    const threeRenderer = new three.WebGLRenderer();
    threeRenderer.setSize(window.innerWidth, window.innerHeight);
    threeRenderer.autoClear = false;
    document.body.appendChild(threeRenderer.domElement);

    // Create a PIXI container with text
    let PIXIRoot = new PIXI.Container();
    const textStyle = {
    fontFamily: 'Arial',
    fontSize: 32,
    fill: "white",
    stroke: "green",
    strokeThickness: 10,
    };
    let message = new PIXI.Text('Hello PIXI.js and three.js!', textStyle);
    PIXIRoot.addChild(message);

    // Create a three.js 3D scene and 2D scene

    const scene = new three.Scene();
    const camera = new three.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    camera.position.z = 10;

    const scene2D = new three.Scene();
    const width = window.innerWidth;
    const height = window.innerHeight;
    const camera2D = new three.OrthographicCamera(width / -2, width / 2, height / 2, height / -2, 1 ,1000);
    camera2D.position.z = 10;

    // Add a mesh to the 3D scene
    const geometry = new three.BoxGeometry(1, 1, 1);
    const material = new three.MeshBasicMaterial({ color: 0x00ff00 });
    const cube = new three.Mesh(geometry, material);
    cube.position.z = 2;
    scene.add(cube);

    // Create a three.js texture to hold the PIXI canvas as a texture
    const uiTexture = new three.Texture(PIXIRenderer.view);
    const uiMaterial = new three.MeshBasicMaterial({
    map: uiTexture,
    transparent: true,
    });
    const uiGeometry = new three.PlaneGeometry(512, 512, 2);
    const uiMesh = new three.Mesh(uiGeometry, uiMaterial);
    uiMesh.position.y = -300;
    scene2D.add(uiMesh);

    render();
}

const render = function render() {
  requestAnimationFrame(render);

  const dt = 1 / 60;

  cube.rotation.x += dt;
  cube.rotation.y += dt;

  PIXIRenderer.render(PIXIRoot);
  uiTexture.needsUpdate = true;

  threeRenderer.render(scene, camera);
  threeRenderer.render(scene2D, camera2D);
};