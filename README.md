# custom-touch-input
unity code for a customized touch based input for the old input system



HOW TO USE-

Player Movement is an entire movement system script with slide, sprint, walk etc.

you need to feed in vector 2's for movement and look around.

touch move is a customized way of getting vector 2s from mobile "joysticks" that work less like joysticks and more like keyboard buttons. I wrote it because I hate joysticks. You an tap a portion of the "joystick" to move instead of draggin the whole thing from the center.

This vector 2 gets fed in player movement and you are good to go.


the lookaround script works in a similar manner, no joysticks. You use the right half of the keyboard as your "trackpad". Any delta detected therein is returned by the function.

if you want to use it, attack movement to you player character.
attach the touchmov script to your UI image object that will work as your "movement stick/buttons"
attack lookaround script to your player character


struggling devs, you are welcome.

PS- I will try to write something similar for the new input system if I can figure out the damn thing in the first place. 

Until then, cheerio!
