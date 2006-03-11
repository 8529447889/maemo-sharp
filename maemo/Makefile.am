
pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = maemo-sharp.pc

MCS=mcs
RAW_API=maemo-api.raw
API=maemo-api.xml
METADATA=maemo.metadata

ASSEMBLY_NAME= maemo-sharp
ASSEMBLY= $(ASSEMBLY_NAME).dll

CODEGEN=gapi2-codegen
FIXUP=gapi2-fixup

sources = Osso.cs

build_sources = AssemblyInfo.cs $(sources)

customs = 
#customs = App.custom Widget.custom Project.custom WidgetClass.custom

CLEANFILES = maemo-sharp.dll generated-stamp generated/*.cs $(API)

DISTCLEANFILES= AssemblyInfo.cs maemo-sharp.pc

noinst_DATA = maemo-sharp.dll

all: generated-stamp maemo-sharp.dll

$(API): $(srcdir)/$(RAW_API) $(srcdir)/$(METADATA)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	$(FIXUP) --api=$(srcdir)/$(API) --metadata=$(srcdir)/$(METADATA)

generated-stamp: $(API)
	 $(CODEGEN) --generate $(srcdir)/$(API) $(GTK_SHARP_CFLAGS) --outdir=generated --customdir=$(srcdir) --assembly-name=maemo-sharp && touch generated-stamp

maemo-sharp.dll: $(build_sources) generated-stamp
	$(MCS) -nowarn:169 -unsafe -target:library $(GTK_SHARP_LIBS) \
	$(build_sources) generated/*.cs -out:maemo-sharp.dll

install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS)";  \
        $(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS)"; \
        $(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS) || exit 1;

EXTRA_DIST = $(RAW_API) $(sources) $(customs) $(METADATA) AssemblyInfo.cs.in maemo-sharp.dll.config.in maemo-sharp.pc.in $(API)
