

Striker:
    If other team has the ball. Strikers will run to attempt to tackle whichever player has the ball. ${STRENGTH} stat determines chance of winning the tackle or just sliding through and not getting the ball.

    If I have the ball I will run with ${SPEED} and ${STAMINA} to the opposite goal and try and avoid opposition defenders.
    If opposition defender is too close I will try to pass to my team mate

    If in target goal box
    -> Raycast from feet to goal
       If no players in the way (except goalie), Shoot - kicks ball based on ${SHOT_POWER} and ${ACCURACY}
       If players are in the way, attempt to pass to team mate. Pass in direction of other striker. ${ACCURACY}

    If I do not have the ball but my teammate striker has it, I will look to run into a place to receive a pass outside the opposition box.


Defender:
    If other team has the ball and..
      They are in their half
      --> I will position myself in between my goal (LEFT/RIGHT POST DEPENDING ON DEFENDER 1 OR 2) and the ball

      They are in our half
      --> I will run to attempt to tackle the striker that has the ball with ${STRENGTH}. If my teammate defender goes to tackle I will hold back, position myself between our goal and the ball and wait for them to tackle. If they fail the tackle I will then attempt to tackle with ${STRENGTH}.


    If our team has the ball
      I will run into an open space on our half of the pitch and be ready to accept a pass OR I will kick the ball ${SHOT_POWER} and ${ACCURACY} to a striker on my team


Goalie:
    If other team has the ball and..
      They are in their half
      --> Will stand in our goal waiting

      They are in our half
      --> I will position myself in our goal move to position myself to the part of the goal (top or bottom side) depending on where the ball is coming from

      They are in our box
      --> I will position myself between the ball and my goal

      
