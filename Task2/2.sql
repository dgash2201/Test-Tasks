select cl.Id, cl.ClientName, count(1) ContactsCount
	from Clients cl
	inner join ClientContacts cnt on cl.Id = cnt.ClientId
	group by cl.Id, cl.ClientName
	having count(1) > 2;