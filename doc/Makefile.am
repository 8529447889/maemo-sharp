if ENABLE_MONODOC
TARGETS = maemo-sharp-docs.zip maemo-sharp-docs.tree maemo-sharp-docs.source
docsdir = $(prefix)/lib/monodoc/sources
docs_DATA = $(TARGETS)
else
TARGETS = 
docsdir = $(datadir)
docs_DATA =
endif

ASSEMBLIES = ../maemo/maemo-sharp.dll

UPDATE_ASSEMBLIES = $(addprefix -assembly:, $(ASSEMBLIES))

maemo-sharp-docs.zip maemo-sharp-docs.tree: $(srcdir)/en/*/*.xml $(srcdir)/en/*.xml
	$(MDASSEMBLER) --ecma $(srcdir)/en -o maemo-sharp-docs

update:
	$(MONODOCER) $(UPDATE_ASSEMBLIES) -path:en

CLEANFILES = maemo-sharp-docs.zip maemo-sharp-docs.tree

EXTRA_DIST = maemo-sharp-docs.source

NAMESPACES=Hildon Libosso

dist-hook:
	mkdir -p $(distdir)/en
	cp $(srcdir)/en/*.xml $(distdir)/en/
	for i in $(NAMESPACES); do                          \
		mkdir -p $(distdir)/en/$$i;                     \
		cp $(srcdir)/en/$$i/*.xml $(distdir)/en/$$i;    \
	done
