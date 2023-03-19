spigot();

module spigot() {
    scale([scale, scale, scale])
    translate([-50, -3/2, 53])
    spigot_handle();
}

module spigot_handle() {
    cube([15, 3, 3]);
}