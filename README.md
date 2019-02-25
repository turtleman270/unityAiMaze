# unityAiMaze

#### What is this?
This is a robot that learns through evolution to solve mazes.

#### How does it work?
It works similar to evolution, the strong survive and breed while the weak die off. In this program, the robots have a **fitness** score, this is how we judge how strong each of the robots are. This score can be increased by moving forward. We start off with 100 robots that have random traits, some might do nothing, or only go straight, or run into a wall and die. What we do is sort these 100 robots based on their fitness score and delete the worst 50. But now we only have 50 robots remaining, so we clone those remaining robots to bring us back up to 100. This is great, but now we have so many duplicate robots, and there will never be any change. To create change, we augment all of the robots slightly, basically to give them minor mutations, some of these will be good mutations (ie. larger muscles so you can run faster) and some will be bad (ie. losing a leg). Then the cycle repeats and ideally all of the bad mutations will die off while the good ones will survive into the next rounds.

### Watch a youtube demo
https://www.youtube.com/watch?v=injN5xl_m5Q
