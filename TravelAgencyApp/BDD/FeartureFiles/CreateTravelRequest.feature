Feature: CreateTravelRequest


Background: Pre-condition
	Given Traveller is Login

Scenario: Traveller can quickly create flight travel request
	Given Traveller is at Travel Create page
	When Traveller fill Plan Trip form: Flight, startDate, endDate, fromPlace, toPlace
	And Traveller click at Im in Hurry button
	Then Success message prompt
 

Scenario: Traveller can create travel request


