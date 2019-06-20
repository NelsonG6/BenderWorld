# RL-Bender
## Explanation of some symbols:
* γ ("gamma") - This is the discount rate. Each step bender takes in an episode lessens the impact of the reward gained on that step, which encourages Bender to clear the board as fast as possible.
* Ɛ ("episolon") - This is the likelihood of selecting a non-optimal action. This is the tendency to explore, versus the tendency to exploit any previous training.
* η ("eta") - The learning rate; the outcome of the reward after having the discount rate applied to it is then applied to the learning rate, to further reduce the impact of a single instance of a reward being gained.
![Image of Yaktocat](https://github.com/NelsonG6/RL-Bender/blob/master/Pictures/Sample.png)
