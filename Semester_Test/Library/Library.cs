using System.Collections.Generic;

namespace Library;

public class Library {
	private List<LibraryResource> _resources;

	public Library(string name)
		=> _resources = new();

	public void AddResource(LibraryResource resource)
		=> _resources.Add(resource);

	public bool HasResource(string name) {
		var resource = _resources.Find(r => r.Name.Equals(name));
		if (resource is null)
			return false;
		return !resource.OnLoan;
	}
}
