using System;
using System.Collections.Generic;

public class PendingActions
{
	public List<IAction> CurrentActions;
	public List<IAction> NextActions;
	public List<IAction> NextNextActions;
	//incase other players advance to the next step and send their action before we advance a step
	public List<IAction> NextNextNextActions;
	
	LockStepManager lsm;
	
	public PendingActions (LockStepManager lsm) {
		this.lsm = lsm;
		CurrentActions = new List<IAction>(lsm.numberOfPlayers);
		NextActions = new List<IAction>(lsm.numberOfPlayers);
		NextNextActions = new List<IAction>(lsm.numberOfPlayers);
		NextNextNextActions = new List<IAction>(lsm.numberOfPlayers);
	}
	
	public void NextTurn() {
		//Finished processing this turns actions
		CurrentActions.Clear();
		List<IAction> swap = CurrentActions;
		
		//last turn's actions is now this turn's actions
		CurrentActions = NextActions;
		
		//last turn's next next actions is now this turn's next actions
		NextActions = NextNextActions;
		
		NextNextActions = NextNextNextActions;
		
		//set NextNextActions to the empty list
		NextNextNextActions = swap;
	}
	
	public bool ReadyForNextTurn() {
		if(NextNextActions.Count == lsm.numberOfPlayers) {
			//if this is the 2nd turn, check if all the actions sent out on the 1st turn have been recieved
			if(lsm.LockStepTurnID == LockStepManager.FirstLockStepTurnID + 1) {
				return true;
			}
			
			//Check if all Actions that will be processed next turn have been recieved
			if(NextActions.Count == lsm.numberOfPlayers) {
				return true;
			}
		}
		
		//if this is the 1st turn, no actions had the chance to be recieved yet
		if(lsm.LockStepTurnID == LockStepManager.FirstLockStepTurnID) {
			return true;
		}
		//if none of the conditions have been met, return false
		return false;
	}
}