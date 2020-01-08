# Bender World
## Explanation of some symbols:
* γ ("gamma") - This is the discount rate. Each step bender takes in an episode lessens the rewards gained on the following steps, which encourages Bender to clear the board as fast as possible.
* Ɛ ("epsilon") - This is the likelihood of selecting a non-optimal action. The agent may take an action based on pure randomness as opposed to comparing outcomes. This is the tendency to explore new options, versus the tendency to exploit any previous training.
* η ("eta") - The learning rate. Rewards gained have the discount (gamma) rate applied, and then have the learning rate applied. This further reduces the impact of a single instance of a reward being gained.
![Image of Yaktocat](https://github.com/NelsonG6/RL-Bender/blob/master/Pictures/Sample.png)
